import { useEffect } from "react"
import { Link } from "react-router-dom"
import useAuth from "../../hooks/useAuth"
import { allPath } from "../../utilities/routes.utility"

const Logout = () => {
    const {setAuth} = useAuth()

    useEffect(() => setAuth(undefined), [])
    
    return (
        <>
        <div>LOGOUT</div>
        </>
    )

}

export default Logout