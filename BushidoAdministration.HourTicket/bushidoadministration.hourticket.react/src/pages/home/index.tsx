import { Link } from "react-router-dom"
import { allRoutes } from "../../utilities/routing.utility"

const Home = () => {    
    return (
        <>
        <div>HOME</div>
        <Link to={allRoutes.details.path}>Details</Link>
        <Link to={allRoutes.login.path}>Login</Link>
        </>
    )
}

export default Home