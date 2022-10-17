import React from "react";
import { useNavigate } from "react-router";
import "./Subject.css";
import { EyeFill, PenFill, TrashFill } from 'react-bootstrap-icons';
import Button from 'react-bootstrap/Button';
import 'bootstrap/dist/css/bootstrap.css';
function Subject(props) {

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
                <Button className="table-button" variant="primary"><PenFill /></Button>
                <Button className="table-button" variant="danger"><TrashFill /></Button>
            </td>
        </tr>
    );

}

export default Subject;