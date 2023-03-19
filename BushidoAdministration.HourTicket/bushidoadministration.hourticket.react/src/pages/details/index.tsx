import { Link } from "react-router-dom"
import { allPath } from "../../utilities/routing.utility"

const Details = () => {
    return (
        <>
        <div>DETAILS</div>
        <Link to={allPath.logout}>Logout</Link>
        </>
    )
}

export default Details