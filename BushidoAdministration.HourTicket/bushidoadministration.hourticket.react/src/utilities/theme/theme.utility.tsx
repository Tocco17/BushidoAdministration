import { createTheme } from "@mui/material";
import { ThemeOptions } from "@mui/material/styles";
import customThemeOptions from "./customThemeOptions";
import palette from "./palette.utility";

const createDefaultTheme = () => {
    const customOptions = customThemeOptions()
    
    const options : ThemeOptions = {
        direction: 'ltr',
        palette: palette(customOptions)
    }

    const theme = createTheme(options)
    return theme
}

export default createDefaultTheme