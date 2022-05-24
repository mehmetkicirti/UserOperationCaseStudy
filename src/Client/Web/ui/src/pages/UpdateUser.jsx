import React, { useEffect } from 'react'
import { useParams } from 'react-router-dom';
import {
    Box, Stack, Grid, Avatar, FormControl,
    FormHelperText,
    Button,
    InputLabel,
    OutlinedInput,
    Typography,
    useMediaQuery,
} from "@mui/material";
import { useTheme } from '@mui/material/styles';
import AdapterDateDayjs from "@mui/lab/AdapterDayjs";
import { LocalizationProvider } from '@mui/lab'

import { toast } from "react-toastify";
import { useSelector, useDispatch } from "react-redux";
// third party
import * as Yup from 'yup';
import { Formik } from 'formik';
// project imports
import useScriptRef from '../hooks/useScriptRef';
import { updateUser, getUserById } from "../redux/features/user/userActions";
import Thumb from '../components/Thumb';
import { formatDate } from '../utils/helpers';


const UpdateUser = () => {
    let { id } = useParams();
    const theme = useTheme();
    const scriptedRef = useScriptRef();
    const matchDownSM = useMediaQuery(theme.breakpoints.down('md'));
    const { error, appUser } = useSelector((state) => ({ ...state.user }));
    const dispatch = useDispatch();

    useEffect(() => {
        error && toast.error(error);
        dispatch(getUserById({ id: id }))
    }, [error, dispatch]);

    const initialValues = {
        name: (appUser != null ? appUser.name : ''),
        surname: (appUser != null ? appUser.surname : ''),
        birthDate: (appUser != null ? formatDate(appUser.birthDate) : ''),
        image: (''),
        submit: null
    };
    const validationSchema = Yup.object().shape({
        name: Yup.string().max(75).required("Name is required"),
        surname: Yup.string().max(75).required("Surname is required"),
        birthDate: Yup.date().required("Birth Date is required"),
        image: Yup.mixed().required('File is required'),
    });

    const onSubmitForm = async (values, { setErrors, setStatus, setSubmitting }) => {
        try {
            if (scriptedRef.current) {
                setStatus({ success: true });
                setSubmitting(false);
            }
            const formData = {
                name: values.name,
                surname: values.surname,
                birthDate: values.birthDate,
                image: values.image ?? appUser.imagePath,
                id: id
            };
            const parameters = {
                formData,
                toast
            }
            dispatch(updateUser(parameters));
        } catch (err) {
            if (scriptedRef.current) {
                setStatus({ success: false });
                setErrors({ submit: err.message });
                setSubmitting(false);
            }
        }
    };

    const inputFormStyle = {
        marginTop: 1,
        marginBottom: 1,
    };

    return (
        <Grid direction={"column"} alignItems={"center"} justifyContent={"flex-start"} container spacing={matchDownSM ? 0 : 2} columns={{ xs: 4, sm: 8, md: 12, height: "100vh" }}>
            <Stack direction={"column"} alignItems={"center"} justifyContent={"flex-start"} color={"text.primary"} sx={{ mt: 5, ml: 2, mr: 2 }}>
                <Typography
                    variant="caption"
                    fontSize="32px"
                    fontWeight={"bold"}
                    gutterBottom
                    textAlign={matchDownSM ? 'center' : 'inherit'}
                >
                    User Details
                </Typography>
                <Formik
                    enableReinitialize
                    initialValues={initialValues}
                    validationSchema={validationSchema}
                    onSubmit={onSubmitForm}
                >
                    {({ errors, handleBlur, handleChange, handleSubmit, isSubmitting, touched, values, setFieldValue }) => (
                        <form noValidate onSubmit={handleSubmit}>
                            <FormControl sx={{ mb: 1, }} fullWidth error={Boolean(touched.name && errors.name)}>
                                <InputLabel htmlFor="outlined-adornment-name-login">Name</InputLabel>
                                <OutlinedInput
                                    id="outlined-adornment-name-login"
                                    type="text"
                                    value={values.name}
                                    name="name"
                                    onBlur={handleBlur}
                                    onChange={handleChange}
                                    label="Name"
                                    inputProps={{}}
                                />
                                {touched.name && errors.name && (
                                    <FormHelperText error id="standard-weight-helper-text-name-login">
                                        {errors.name}
                                    </FormHelperText>
                                )}
                            </FormControl>

                            <FormControl fullWidth error={Boolean(touched.surname && errors.surname)}>
                                <InputLabel htmlFor="outlined-adornment-surname-login">Surname</InputLabel>
                                <OutlinedInput
                                    id="outlined-adornment-email-login"
                                    type="text"
                                    value={values.surname}
                                    name="surname"
                                    onBlur={handleBlur}
                                    onChange={handleChange}
                                    label="Surname"
                                    inputProps={{}}
                                />
                                {touched.surname && errors.surname && (
                                    <FormHelperText error id="standard-weight-helper-text-surname-login">
                                        {errors.surname}
                                    </FormHelperText>
                                )}
                            </FormControl>

                            <FormControl sx={inputFormStyle} fullWidth error={Boolean(touched.birthDate && errors.birthDate)}>
                                <InputLabel htmlFor='outlined-adornment-surname'>Birth Date</InputLabel>
                                <LocalizationProvider dateAdapter={AdapterDateDayjs}>
                                    <OutlinedInput
                                        id="outlined-adornment-birthDate"
                                        type='date'
                                        value={values.birthDate}
                                        name="birthDate"
                                        onBlur={handleBlur}
                                        onChange={handleChange}
                                        label="Birth Date"
                                        inputProps={{
                                        }}
                                    />
                                </LocalizationProvider>
                                {touched.birthDate && errors.birthDate && (
                                    <FormHelperText error id="standard-weight-helper-text-birthdate">
                                        {errors.birthDate}
                                    </FormHelperText>
                                )}
                            </FormControl>

                            <FormControl sx={inputFormStyle} fullWidth error={Boolean(touched.image && errors.image)}>
                                <div className="form-group">
                                    <OutlinedInput id="file" name="file" type="file" onChange={(event) => {
                                        setFieldValue("image", event.currentTarget.files[0]);
                                    }} className="form-control">
                                    </OutlinedInput>
                                    <Thumb file={values.image} />
                                </div>
                                {touched.image && errors.image && (
                                    <FormHelperText error id="standard-weight-helper-text-image">
                                        {errors.image}
                                    </FormHelperText>
                                )}
                            </FormControl>

                            {errors.submit && (
                                <Box sx={{ mt: 3 }}>
                                    <FormHelperText error>{errors.submit}</FormHelperText>
                                </Box>
                            )}
                            <Box sx={{ mt: 2 }}>
                                <Button
                                    disableElevation
                                    disabled={isSubmitting}
                                    fullWidth
                                    size="large"
                                    type="submit"
                                    variant="contained"
                                    color="secondary"
                                >
                                    Update User
                                </Button>
                            </Box>
                        </form>
                    )}
                </Formik>
            </Stack>
        </Grid>
    )
}

export default UpdateUser;