import { DatePicker, DateValidationError } from "@mui/x-date-pickers"
import { PickerChangeHandlerContext } from "@mui/x-date-pickers/internals/hooks/usePicker/usePickerValue"
import useAuth from "../../hooks/useAuth"

const Timesheet = () => {
    const auth = useAuth()

    const handleDatePickerChange = (value: unknown, context: PickerChangeHandlerContext<DateValidationError>) => {
        
    }

    return (
        <>
        <DatePicker onChange={handleDatePickerChange}/>
        </>
    )
}

export default Timesheet