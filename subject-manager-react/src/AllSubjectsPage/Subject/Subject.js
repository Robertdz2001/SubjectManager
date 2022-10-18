import React from "react";
import { useNavigate } from "react-router";
import "./Subject.css";
import { EyeFill, PenFill, TrashFill } from 'react-bootstrap-icons';
import Button from 'react-bootstrap/Button';
import 'bootstrap/dist/css/bootstrap.css';
import axios from "axios";
function Subject(props) {
    const navigate = useNavigate();
    const dayToString = (dayNumber) => {
        switch (dayNumber) {
            case 0:
                return "Sunday";
            case 1:
                return "Monday";
            case 2:
                return "Tuesday";
            case 3:
                return "Wednesday";
            case 4:
                return "Thursday";
            case 5:
                return "Friday";
            case 6:
                return "Saturday";
        }
    }
    const handleDeleteSubject = async () => {

        try {
            const res = await axios.delete(`https://localhost:7158/api/subjects/${props.subject.id}`, {
                headers: {
                    'Authorization': localStorage.getItem("token")
                }
            }
            );
            window.location.reload(false);
        }
        catch (e) {
            alert(e);
        }
    }
    return (
        <tr>
            <td>{props.index}</td>
            <td>{props.subject.name}</td>
            <td>{props.subject.shortName}</td>
            <td><a href={props.subject.platformUrl}>{props.subject.platformUrl}</a></td>
            <td>{props.subject.roomNumber}</td>
            <td>{dayToString(props.subject.dayOfWeek)}</td>
            <td>{props.subject.time}</td>
            <td className="table-buttons">
                <Button className="table-button" variant="dark"><EyeFill /></Button>
                <Button className="table-button" variant="primary" onClick={() => { navigate(`/subjects/update/${props.subject.id}`) }}><PenFill /></Button>
                <Button className="table-button" variant="danger" onClick={handleDeleteSubject}><TrashFill /></Button>
            </td>
        </tr>
    );

}

export default Subject;