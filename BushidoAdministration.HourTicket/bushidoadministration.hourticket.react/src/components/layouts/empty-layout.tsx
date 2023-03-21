import { Link, Outlet } from "react-router-dom"
import { allPath } from "../../utilities/routes.utility"
import GoBackButton from "../buttons/go-back-button"

const EmptyLayout = () => {
    return (
        <>
        <nav>
            <ul>
                <li>
                    <Link to={allPath.home}>Home</Link>
                </li>
                <li>
                    <GoBackButton label="Torna indietro"/>
                </li>
            </ul>
        </nav>
        <Outlet />
        
        </>
    )
}

export default EmptyLayout