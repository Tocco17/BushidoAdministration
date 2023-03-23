import { CssBaseline } from "@mui/material"
import { ThemeProvider } from "@mui/material/styles"
import {DefaultTheme} from "@mui/private-theming/defaultTheme"
import { createContext, ReactElement, ReactNode, useState } from "react"
import createDefaultTheme from "../utilities/theme/theme.utility"

type ThemeContextType = {
    theme: DefaultTheme
    setTheme: React.Dispatch<React.SetStateAction<DefaultTheme>>
}

const ThemeContext = createContext<ThemeContextType>({
    theme: createDefaultTheme(),
    setTheme: () => {}
})

type CustomThemeProviderProps = {
    children : ReactElement
}

const CustomThemeProvider = ({children} : CustomThemeProviderProps) => {
    const [theme, setTheme] = useState<DefaultTheme>(createDefaultTheme())

    return (
        <>
        <ThemeContext.Provider value={{theme, setTheme}}>
            <ThemeProvider theme={theme}>
                <CssBaseline />
                {children}
            </ThemeProvider>
        </ThemeContext.Provider>
        </>
    )
}

export default CustomThemeProvider