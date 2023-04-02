import UsersDb from "../db/users.db"
import useAuth from "../../hooks/useAuth"
import User from "../../models/entities/User"

const loginApi = (email: string, password: string) => {
    const user = UsersDb.find(u => u.email === email && u.password === password)

    return user
}

export default loginApi