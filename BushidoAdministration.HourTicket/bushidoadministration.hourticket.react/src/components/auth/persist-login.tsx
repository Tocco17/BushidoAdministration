import { useEffect, useState } from "react"
import { Outlet } from "react-router-dom"
import useAuth from "../../hooks/useAuth"
import useRefreshToken from "../../hooks/useRefreshToken"

const PersistLogin = () => {
    const [isLoading, setIsLoading] = useState(true)
    const refresh = useRefreshToken()
    const {auth, persist} = useAuth()

    useEffect(() => {
        let isMounted = true

        const verifyRefreshToken = async () => {
            try {
                await refresh()
            } catch (error) {
                console.error(error)                
            } finally {
                isMounted && setIsLoading(false)
            }
        }

        !auth?.accessToken && persist ? verifyRefreshToken() : setIsLoading(false)

        isMounted = false
    }, [])

    
    if(persist && isLoading) return <p>Loading...</p>
    return <Outlet/>
}

export default PersistLogin