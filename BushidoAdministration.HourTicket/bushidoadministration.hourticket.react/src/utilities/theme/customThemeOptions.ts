import { TypeBackground } from "@mui/material/styles"

export interface CustomThemeOptionInterface {
    background: {
        default: string
    },
    text: {
        primary: string
    }
}

const customThemeOption : () => CustomThemeOptionInterface = () => {
    return {
        background: {
            default: '#fff'
        },
        text: {
            primary: '#000'
        }
    }
}

export default customThemeOption