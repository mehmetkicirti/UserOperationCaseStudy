import { 
    ModeNight, } from '@mui/icons-material';
import {
    AppBar, 
    styled, 
    Toolbar, 
    Typography, 
    ListItem,
    ListItemButton,
    ListItemIcon,
    Switch,
} from '@mui/material';
import React from 'react'
import { Link } from 'react-router-dom';

const StyledToolbar = styled(Toolbar)({
    display: "flex",
    justifyContent: "space-between",
})


const Navbar = ({mode, setMode}) => {
    return (
        <AppBar color={"inherit"} position={"sticky"}>
            <StyledToolbar>
                <Link to={`/`} style={{ textDecoration: 'none', display: 'block', color:"black" }}>
                    <Typography variant='h6' sx={{ display: { xs: "none", sm: "block" } }}>
                        UserOpsCase
                    </Typography>
                </Link>
                <ListItem disablePadding>
                    <ListItemButton component="a" href="#">
                        <ListItemIcon>
                            <ModeNight />
                        </ListItemIcon>
                        <Switch onChange={e => setMode(mode === "light" ? "dark" : "light")} />
                    </ListItemButton>
                </ListItem>
            </StyledToolbar>
        </AppBar>
    )
}

export default Navbar;