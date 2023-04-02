interface ThemeInterface {
    colors: {
        readonly [key: string]: string
    }
    heading: string
    paper: string
    backgroundDefault: string
    background: string
    darkTextPrimary: string
    darkTextSecondary: string
    textDark: string
    menuSelected: string
    menuSelectedBack: string
    divider: string
    customization: any
}

export default ThemeInterface