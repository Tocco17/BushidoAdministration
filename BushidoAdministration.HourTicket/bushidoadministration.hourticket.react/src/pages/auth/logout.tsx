import { useEffect } from "react"
import { Link } from "react-router-dom"
import useAuth from "../../hooks/useAuth"
import { allPath } from "../../utilities/routing.utility"

const Logout = () => {
    const {setAuth} = useAuth()

    useEffect(() => setAuth(undefined), [])
    
    return (
        <>
        <div>LOGOUT</div>
        <Link to={allPath.home}>Home</Link>
        <Link to={allPath.details}>Details</Link>
        </>
    )

}

export default Logout