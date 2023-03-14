import Role from "../interfaces/Role";
import User from "../interfaces/User";
import RolesDb from "./roles.db";

const UsersDb : User[] = [
    {
        id: 1,
        email: 'president@admin.com',
        password: 'admin',
        roles: [
            {
                id: 1,
                name: 'admin'
            }
        ]
    }
]

export default UsersDb