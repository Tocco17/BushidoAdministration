import { useLocation, useNavigate } from "react-router-dom";

interface IProps {
    label: string;
  }

const GoBackButton = ({label} : IProps) => {
    const navigate = useNavigate()
    
    const handleOnClick = () => {
        navigate(-1);
    }
    
    return (
        <>
        <button onClick={handleOnClick}>{label}</button>
        </>
    )
}

export default GoBackButton