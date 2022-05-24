import { Box, createTheme, Stack, ThemeProvider } from '@mui/material';
import React, {useState} from 'react'
import Add from '../components/Add';
import Navbar from '../components/Navbar';
import { getDesignTokens } from '../utils/theme';

const MainLayout = ({children}) => {
  const [mode, setMode] = useState("light");
  

  const darkTheme = createTheme(getDesignTokens(mode));

  return (
    <ThemeProvider theme={darkTheme}>
        <Box bgColor={"background.default"} color={"text.primary"}>
            <Navbar mode={mode} setMode={setMode} />
            <Stack direction={"row"} alignItems={"space-between"} sx={{height:"calc(100vh-68px)"}}>
                {children}
            </Stack>
            <Add/>
        </Box>
    </ThemeProvider>
  )
}

export default MainLayout;