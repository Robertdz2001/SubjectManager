import React from "react";
import { useNavigate } from "react-router";
import "./Test.css";
import { EyeFill, PenFill, TrashFill } from 'react-bootstrap-icons';
import Button from 'react-bootstrap/Button';
import 'bootstrap/dist/css/bootstrap.css';
import axios from "axios";

function Test(props) {

    const navigate = useNavigate();
    const formatDate = (date) => {
        const formattedDate = date.replace('T', ' ').slice(0, 19);
        return formattedDate;
    }
    const handleDelete = async () => {
        try {
            const res = await axios.delete(`https://localhost:7158/api/subjects/${props.test.subject.id}/tests/${props.test.id}`, {
                headers: {
                    'Authorization': localStorage.getItem("token")
                }
            })
            window.location.reload(false);
        }
        catch (e) {
            alert(e);
        }
    }

    return (
        <tr>
            <td>{props.index}</td>
            <td>{props.test.name}</td>
            <td>{formatDate(props.test.date)}</td>
            <td className="table-buttons">
                <Button className="table-button" variant="dark"><EyeFill /></Button>
                <Button className="table-button" variant="primary" onClick={() => { console.log(props.test); navigate(`/subjects/${props.test.subject.id}/tests/${props.test.id}`) }}><PenFill /></Button>
                <Button className="table-button" variant="danger" onClick={handleDelete}><TrashFill /></Button>
            </td>
        </tr>
    );

}

export default Test;