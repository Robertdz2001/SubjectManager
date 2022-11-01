import React from "react";
import { useNavigate } from "react-router";
import { EyeFill, PenFill, TrashFill } from 'react-bootstrap-icons';
import Button from 'react-bootstrap/Button';
import 'bootstrap/dist/css/bootstrap.css';
import axios from "axios";
import { url } from "../App/App";
export const formatDate = (date) => {
    const formattedDate = date.replace('T', ' ').slice(0, 19);
    return formattedDate;
}
function Test(props) {

    const navigate = useNavigate();

    const handleDelete = async () => {
        try {
            const res = await axios.delete(`${url}/api/subjects/${props.test.subject.id}/tests/${props.test.id}`, {
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
                <Button className="table-button" variant="dark" onClick={() => { navigate(`/subjects/${props.test.subject.id}/tests/${props.test.id}/view`) }}><EyeFill /></Button>
                <Button className="table-button" variant="primary" onClick={() => { navigate(`/subjects/${props.test.subject.id}/tests/${props.test.id}/update`) }}><PenFill /></Button>
                <Button className="table-button" variant="danger" onClick={handleDelete}><TrashFill /></Button>
            </td>
        </tr>
    );

}

export default Test;