import { Link } from "react-router-dom"
import { allPath } from "../../utilities/routing.utility"

const Home = () => {    
    return (
        <>
        <div>HOME</div>
        <Link to={allPath.details}>Details</Link>
        <Link to={allPath.login}>Login</Link>
        </>
    )
}

export default Home