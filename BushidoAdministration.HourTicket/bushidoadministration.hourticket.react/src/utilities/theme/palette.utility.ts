import { PaletteOptions } from "@mui/material/styles"
import { CustomThemeOptionInterface } from "./customThemeOptions"

const palette : (options : CustomThemeOptionInterface) => PaletteOptions  = (options) => {
    return {
        background: {
            default: options.background.default,
            // paper: options.background.default
        },
        text: {
            primary: options.text.primary
        }
    }
}

export default palette