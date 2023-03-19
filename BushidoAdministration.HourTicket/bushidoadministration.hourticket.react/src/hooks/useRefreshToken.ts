import refreshToken from "../api/auth/refresh-token"
import useAuth from "./useAuth"

const useRefreshToken = () => {
    const {setAuth} = useAuth()

    const refresh = async () => {
        const response = await refreshToken()

        setAuth(prev => {
            return {
                ...prev,
                roles: response.data.roles,
                accessToken: response.data.accessToken
            }
        })

        return response.data.accessToken
    }

    return refresh
}

export default useRefreshToken