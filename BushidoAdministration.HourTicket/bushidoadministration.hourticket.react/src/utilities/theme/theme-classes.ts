import { SxProps, Theme } from "@mui/material";

export type CssClass = SxProps<Theme>

const getCssClass = (cssClasses: CssClass[]) => cssClasses.reduce((p, c) => ({...p,...c}), {})
export default getCssClass

export const container: CssClass = {
    display: 'flex'
}


export const flexRow: CssClass = {
    display: 'flex',
    flexDirection: 'row',
}

export const alignCenter: CssClass = {
    alignItems: 'center'
}

export const fontSize = (size: number, dimension = 'px') => (
    {
        fontSize: `${size}${dimension}`
    } as CssClass
)

export const verticalAlign: CssClass = {
    verticalAlign: 'center'
}