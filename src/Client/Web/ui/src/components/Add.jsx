import React, { useState, useEffect } from 'react';
import {toast} from "react-toastify";
import { useDispatch, useSelector } from 'react-redux';
import {
    Button,
    ButtonGroup,
    Fab,
    Modal,
    Box,
    styled,
    Tooltip,
    Typography,
    Grid,
    FormControl,
    InputLabel,
    OutlinedInput,
    FormHelperText,
} from "@mui/material";
import {
    Add as AddIcon,
} from "@mui/icons-material";
import AdapterDateDayjs from "@mui/lab/AdapterDayjs";
import { LocalizationProvider } from '@mui/lab'
import { Formik } from 'formik';
import * as Yup from "yup";
import Thumb from './Thumb';
import useScriptRef from '../hooks/useScriptRef';
import { createUser } from '../redux/features/user/userActions';
import { formatDate } from '../utils/helpers';

const StyledModal = styled(Modal)({
    display: "flex",
    alignItems: "center",
    justifyContent: "center",
    zIndex: 1,
    left: 0,
    top: 0,
    width: "100%",
    height: "100%",
    overflow: "auto",
    position: 'fixed'
});




const Add = () => {
    const [open, setOpen] = useState(false);
    const dispatch = useDispatch();
    const scriptedRef = useScriptRef();
    const {error} = useSelector((state) => ({...state.user}));


    useEffect(()=>{
        if(error){
            toast.error(error);
            
        }
    }, [error]);



    const initialValues = {
        name: '',
        surname: '',
        birthDate: formatDate(Date.now()),
        image: "",
        submit: null
    };
    const validationSchema = Yup.object().shape({
        name: Yup.string().max(75).required("Name is required"),
        surname: Yup.string().max(75).required("Surname is required"),
        birthDate: Yup.date().required("Birth Date is required"),
        image: Yup.mixed().required('File is required'),
    });

    const onSave = async (values, { setErrors, setStatus, setSubmitting }) => {
        try {
            if (scriptedRef.current) {
                setStatus({ success: true });
                setSubmitting(false);
            }
            const formData = {
                name: values.name,
                surname: values.surname,
                image: values.image,
                birthDate: values.birthDate
            }
            dispatch(createUser({formData, toast, setOpen}));
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
        <>
            <Tooltip
                onClick={(e) => setOpen(true)}
                title="Create User"
                sx={{
                    position: "fixed",
                    bottom: 20,
                    left: { xs: "calc(50% - 25px)", md: 30 },
                }}
            >
                <Fab color="primary" aria-label="add">
                    <AddIcon />
                </Fab>
            </Tooltip>
            <StyledModal
                open={open}
                onClose={(e) => setOpen(false)}
                aria-labelledby="modal-modal-title"
                aria-describedby="modal-modal-description"
            >
                <Box
                    sx={{ margin: "15% auto", backgroundColor: "#fefefe", width: { xs: "80%", md: "50%" } }}
                    p={3}
                    borderRadius={5}
                >
                    <Typography variant="h6" color="gray" textAlign="center">
                        Create User
                    </Typography>
                    <Grid container direction="column" justifyContent={"center"} spacing={2}>
                        <Grid item xs={12}>
                            <Formik
                                initialValues={initialValues}
                                validationSchema={validationSchema}
                                onSubmit={onSave}
                            >
                                {({ errors, handleBlur, handleChange, handleSubmit, isSubmitting, touched, values, setFieldValue }) => (
                                    <form noValidate onSubmit={handleSubmit}>
                                        <FormControl sx={inputFormStyle} fullWidth error={Boolean(touched.name && errors.name)}>
                                            <InputLabel htmlFor='outlined-adornment-name'>Name</InputLabel>
                                            <OutlinedInput
                                                id="outlined-adornment-name"
                                                type='text'
                                                value={values.name}
                                                name="name"
                                                onBlur={handleBlur}
                                                onChange={handleChange}
                                                label="Name"
                                                inputProps={{
                                                }}
                                            />
                                            {touched.name && errors.name && (
                                                <FormHelperText error id="standard-weight-helper-text-name">
                                                    {errors.name}
                                                </FormHelperText>
                                            )}
                                        </FormControl>

                                        <FormControl sx={inputFormStyle} fullWidth error={Boolean(touched.surname && errors.surname)}>
                                            <InputLabel htmlFor='outlined-adornment-surname'>Surname</InputLabel>
                                            <OutlinedInput
                                                id="outlined-adornment-surname"
                                                type='text'
                                                value={values.surname}
                                                name="surname"
                                                onBlur={handleBlur}
                                                onChange={handleChange}
                                                label="Surname"
                                                inputProps={{
                                                }}
                                            />
                                            {touched.surname && errors.surname && (
                                                <FormHelperText error id="standard-weight-helper-text-surname">
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
                                                }} className="form-control" />
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
                                        <ButtonGroup
                                            variant="contained"
                                            aria-label="outlined primary button group"
                                            sx={{
                                                width: {
                                                    xs: "100%",
                                                    md: "70px"
                                                },
                                                float: "right"
                                            }}
                                        >
                                            <Button
                                                disableElevation
                                                disabled={isSubmitting}
                                                sx={{ fontSize: { xs: "12px", sm: "16px" }, width: { xs: "100%" } }}
                                                type="submit"
                                                variant="contained"
                                                color="primary"
                                                onClick={(e) => console.log(e)}
                                            >
                                                SAVE
                                            </Button>
                                        </ButtonGroup>
                                    </form>
                                )}
                            </Formik>

                        </Grid>
                    </Grid>

                </Box>
            </StyledModal>
        </>
    )
}

export default Add;