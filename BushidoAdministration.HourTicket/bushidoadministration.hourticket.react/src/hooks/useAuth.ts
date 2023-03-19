import { useContext } from "react"
import AuthContext from "../stores/auth-provider"

const useAuth = () => useContext(AuthContext)

export default useAuth