import { Navigate, Outlet, useLocation } from "react-router-dom"
import Role from "../../enums/role.enum"
import useAuth from "../../hooks/useAuth"
import { allRoutes } from "../../utilities/routing.utility"

type RequireAuthProps = {
    allowedRoles: Role[]
}

const RequireAuth = ({allowedRoles}: RequireAuthProps) => {
    const { auth } = useAuth()
    const location = useLocation()

    if(!auth || !auth.user)
        return <Navigate to={allRoutes.login.path} state={{from: location}} replace/>

    const roles = auth?.user.roles
    if(roles.length != 0 && !roles.find(role => allowedRoles.includes(role)))
        return <Navigate to={allRoutes.unauthorized.path} state={{from: location}} replace />
    
    return <Outlet/>
}

export default RequireAuth