import Role from "../../models/enums/role.enum";
import User from "../../models/entities/User";

const UsersDb : User[] = [
    {
        id: 1,
        email: 'president@admin.com',
        password: 'admin',
        roles: [
            Role.admin
        ]
    }
]

export default UsersDb