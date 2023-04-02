import Base from "./Base";
import Lesson from "./Lesson";
import Schedule from "./Schedule";

export interface LessonScheduleBase extends Base {
    idLesson: number
    idSchedule: number
}

export interface LessonSchedule extends Base {
    lesson: Lesson
    schedule: Schedule
}