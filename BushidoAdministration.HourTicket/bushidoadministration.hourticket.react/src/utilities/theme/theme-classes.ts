import { SxProps, Theme } from "@mui/material";

export type CssClass = SxProps<Theme>

const getCssClass = (cssClasses: CssClass[]) => cssClasses.reduce((p, c) => ({...p,...c}), {})
export default getCssClass

export const container: CssClass = {
    display: 'flex'
}