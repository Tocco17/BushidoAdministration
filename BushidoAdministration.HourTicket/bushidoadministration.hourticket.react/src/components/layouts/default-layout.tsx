import { Link, Outlet } from "react-router-dom"
import { allPath, allRoutes } from "../../utilities/routes/routes.utility"
import GoBackButton from "../buttons/go-back-button"
import NavbarComponent from "../navbar/navbar"
import { Container } from "@mui/material"
import { CssClass } from "../../utilities/theme/theme-classes"

const DefaultLayout = () => {
    const mainContainer: CssClass = {
        // mx: 1, 
        marginTop: 1,
        minHeight: '100vh',
        minWidth: '100vh', 
        maxWidth: '100vh', 
        width: '100%', 
        display: 'flex', 
        flexDirection: 'column',
        alignItems: 'center',
        gap: 1
    }

    return (
        <>
        <Container sx={mainContainer}>

            <NavbarComponent routes={[allRoutes.home, allRoutes.details, allRoutes.timesheet]} settings={[allRoutes.login, allRoutes.logout]} />

            <GoBackButton label="Torna indietro"/>

            <Container sx={{flexGrow: 1}}>
                <Outlet />

            </Container>
        </Container>        
        </>
    )
}

export default DefaultLayout