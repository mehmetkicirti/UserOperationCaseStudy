import { amber, grey, deepPurple } from '@mui/material/colors';
export const getDesignTokens = (mode) => ({
    palette: {
      mode,
      ...(mode === 'light'
        ? {
            // palette values for light mode
            primary: amber,
            divider: amber[200],
            text: {
              primary: grey[900],
              secondary: grey[800],
            },
          }
        : {
            // palette values for dark mode
            primary: deepPurple,
            divider: deepPurple[700],
            background: {
              default: deepPurple[900],
              paper: deepPurple[900],
            },
            text: {
              primary: '#aaa',
              secondary: grey[500],
            },
          }),
    },
  });