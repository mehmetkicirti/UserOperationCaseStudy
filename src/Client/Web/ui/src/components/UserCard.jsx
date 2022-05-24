import { useState } from "react";
import { useDispatch } from "react-redux";
import {
    Avatar,
    Card,
    CardActions,
    CardContent,
    CardHeader,
    Modal,
    styled,
    Box,
    ButtonGroup,
    Button,
    IconButton,
    Typography,
} from "@mui/material";
import CloseIcon from '@mui/icons-material/Close';
import { toast } from "react-toastify";
import { deleteUser } from "../redux/features/user/userActions";
import { formatDate } from "../utils/helpers";
import { Link } from "react-router-dom";

const UserCard = ({ userItem }) => {
    const dispatch = useDispatch();
    const [openModal, setOpenModal] = useState(false);

    const SytledModal = styled(Modal)({
        display: "flex",
        alignItems: "center",
        justifyContent: "center",
    });

    const onReject = (event) => {
        setOpenModal(false);
    }

    const onApprove = () => {
        if (userItem.id != null) {
            dispatch(deleteUser({ id: userItem.id, setOpenModal, toast }))
        }
    };

    return (
        userItem && userItem != null ?
            <>
                <Card sx={{ margin: 5 }}>
                    <CardHeader
                        avatar={
                            <Avatar sx={{ bgcolor: "red" }} aria-label="recipe">
                                {`${userItem.name.toUpperCase().at(0)}`}
                            </Avatar>
                        }
                        action={
                            <IconButton onClick={(e) => setOpenModal(true)} aria-label="settings">
                                <CloseIcon />
                            </IconButton>
                        }
                        title={`${userItem.name} ${userItem.surname}`}
                    />
                    <Link to={`/users/${userItem.id}`} style={{ textDecoration: 'none', display: 'block', color:"black" }}>
                        <CardContent>
                            <Box
                                component="img"
                                sx={{
                                    height: 233,
                                    width: 350,
                                    cursor: "pointer",
                                    maxHeight: { xs: 233, md: 167 },
                                    maxWidth: { xs: 350, md: 250 },
                                }}

                                alt={`${userItem.name} ${userItem.surname}`}
                                src={userItem.image}
                            />
                        </CardContent>
                    </Link>
                    <CardActions disableSpacing>
                        <Typography variant="body2" color="text.secondary">
                            {formatDate(userItem.birthDate)}
                        </Typography>
                    </CardActions>
                </Card>
                <SytledModal
                    open={openModal}
                    onClose={(e) => setOpenModal(false)}
                    aria-labelledby="modal-modal-title"
                    aria-describedby="modal-modal-description"
                >
                    <Box
                        width={400}
                        height={110}
                        bgcolor={"background.default"}
                        color={"text.primary"}
                        p={3}
                        m={2}
                        borderRadius={5}
                    >
                        <Typography variant="h6" color="gray" textAlign="center">
                            Do you want to remove the user?
                        </Typography>
                        <ButtonGroup
                            variant="contained"
                            aria-label="outlined primary button group"
                            style={
                                {
                                    display: "flex",
                                    justifyContent: "space-evenly",
                                    border: "none",
                                    outline: "none",
                                    boxShadow: "none"
                                }
                            }
                        >
                            <Button
                                disableElevation
                                fullWidth
                                size="large"
                                type="submit"
                                variant="contained"
                                color="error"
                                onClick={onReject}
                            >
                                No
                            </Button>
                            <Button
                                disableElevation
                                fullWidth
                                size="large"
                                type="submit"
                                variant="contained"
                                color="success"
                                onClick={onApprove}
                            >
                                Yes I want
                            </Button>
                        </ButtonGroup>
                    </Box>
                </SytledModal>
            </> : <></>
    );
};

export default UserCard;