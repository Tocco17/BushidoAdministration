import { Navigate, Outlet, useLocation } from "react-router-dom"
import Role from "../../enums/role.enum"
import useAuth from "../../hooks/useAuth"

type RequireAuthProps = {
    allowedRoles: Role[]
}

const RequireAuth = ({allowedRoles} : RequireAuthProps) => {
    const { auth } = useAuth()
    const location = useLocation()


    if(auth?.roles.find((role: Role) => allowedRoles?.includes(role)))
        return <Outlet />
    
    return (
        auth?.user
            ? <Navigate to="/unauthorized" state={{from: location}} replace/>
            : <Navigate to="/login" state={{from: location}} replace/>
    )
}

export default RequireAuth