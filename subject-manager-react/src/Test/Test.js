import React from "react";
import { useNavigate } from "react-router";
import "./Test.css";
import { EyeFill, PenFill, TrashFill } from 'react-bootstrap-icons';
import Button from 'react-bootstrap/Button';
import 'bootstrap/dist/css/bootstrap.css';
import axios from "axios";

function Test(props) {

    const formatDate = (date) => {
        const startOfTime = date.indexOf("T");
        const formattedDate = date.replace('T', ' ').slice(0, 19);
        return formattedDate;
    }

    return (
        <tr>
            <td>{props.index}</td>
            <td>{props.test.name}</td>
            <td>{formatDate(props.test.date)}</td>
            <td className="table-buttons">
                <Button className="table-button" variant="dark"><EyeFill /></Button>
                <Button className="table-button" variant="primary"><PenFill /></Button>
                <Button className="table-button" variant="danger" /*onClick={handleDeleteSubject}*/><TrashFill /></Button>
            </td>
        </tr>
    );

}

export default Test;