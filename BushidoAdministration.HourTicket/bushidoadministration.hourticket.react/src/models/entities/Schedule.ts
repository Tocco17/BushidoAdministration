import Week from "../enums/week.enum";
import Base from "./Base";

interface Schedule extends Base {
    weekDay: Week
    beginningTime: string
    endingTime: string
}

export default Schedule

