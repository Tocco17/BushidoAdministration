import { Link } from "react-router-dom"
import { allPath } from "../../utilities/routing.utility"

const NoPage = () => {
    return (
        <>
        <div>No Page</div>
        <Link to={allPath.home}>Home</Link>
        </>
    )
}

export default NoPage