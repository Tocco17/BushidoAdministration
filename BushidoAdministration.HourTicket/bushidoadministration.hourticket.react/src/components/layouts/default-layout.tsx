import { Link, Outlet } from "react-router-dom"
import { allPath, allRoutes } from "../../utilities/routes/routes.utility"
import GoBackButton from "../buttons/go-back-button"
import NavbarComponent from "../navbar/navbar"

const DefaultLayout = () => {
    return (
        <>
        <NavbarComponent routes={[allRoutes.home, allRoutes.details]} settings={[allRoutes.login, allRoutes.logout]} />

        <GoBackButton label="Torna indietro"/>

        <Outlet />
        </>
    )
}

export default DefaultLayout