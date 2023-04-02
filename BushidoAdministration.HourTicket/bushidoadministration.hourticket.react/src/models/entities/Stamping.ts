import Base from "./Base";
import { LessonSchedule } from "./LessonSchedule";
import User from "./User";

export interface StampingBase extends Base {
    idUser: number
    idLessonSchedule: number
    hour: string
}

export interface Stamping extends Base {
    user: User
    lessonSchedule: LessonSchedule
    hour: string
}