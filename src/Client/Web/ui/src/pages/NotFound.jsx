import React from 'react'
import { Box, Grid} from "@mui/material";
import ConstructionIcon from '@mui/icons-material/Construction';
const NotFound = ({errorValue}) => {
  return (
    <Grid container direction="column" justifyContent={"center"} spacing={2} flex alignItems={"center"} sx={{height:"calc(100vh - 136px)"}}>
        <Grid item justifyContent={"center"} xs={12}>
            <Box
                sx={{
                    width: 250,
                    height: "100%",
                    display: "flex",
                    flexDirection:"column",
                    justifyContent:"center",
                    alignItems:"center"
                }}
            >
                <ConstructionIcon sx={{                    color: 'primary.dark',
                    '&:hover': {
                    color: 'primary.main',
                    opacity: [0.9, 0.8, 0.7],
                    },}} fontSize='large'/>
                {errorValue}
            </Box>
            
        </Grid>
        
    </Grid>
  )
}

export default NotFound;