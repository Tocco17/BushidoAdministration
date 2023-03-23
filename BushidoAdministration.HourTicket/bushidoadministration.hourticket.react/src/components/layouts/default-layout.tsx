import { Link, Outlet } from "react-router-dom"
import { allPath } from "../../utilities/routes/routes.utility"
import GoBackButton from "../buttons/go-back-button"

const DefaultLayout = () => {
    return (
        <>
        <nav>
            <ul>
                <li>
                    <Link to={allPath.home}>Home</Link>
                </li>
                <li>
                    <Link to={allPath.details}>Details</Link>
                </li>
                <li>
                    <Link to={allPath.login}>Login</Link>
                </li>
                <li>
                    <Link to={allPath.logout}>Logout</Link>
                </li>
            </ul>
        </nav>

        <GoBackButton label="Torna indietro"/>

        <Outlet />
        </>
    )
}

export default DefaultLayout