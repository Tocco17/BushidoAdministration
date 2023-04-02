import Schedule from "../../models/entities/Schedule";
import Week from "../../models/enums/week.enum";

const scheduleDb : Schedule[] = [
    {id: 1, weekDay: Week.thursday, beginningTime: '17:00', endingTime: '18:00'},
    {id: 2, weekDay: Week.thursday, beginningTime: '18:00', endingTime: '19:00'},
    {id: 3, weekDay: Week.friday, beginningTime: '17:00', endingTime: '18:00'},
    {id: 4, weekDay: Week.friday, beginningTime: '18:00', endingTime: '19:00'},
]

export default scheduleDb