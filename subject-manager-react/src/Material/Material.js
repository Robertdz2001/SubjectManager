import React from "react";
import "./Material.css";
import { useNavigate } from "react-router";
import { EyeFill, PenFill, TrashFill } from 'react-bootstrap-icons';
import Button from 'react-bootstrap/Button';
import 'bootstrap/dist/css/bootstrap.css';
import axios from "axios";

const formatText = (text) => {

    if (text.length >= 15) {
        text = text.slice(0, 15);
        text += "...";
    }

    return text;
}

function Material(props) {

    const navigate = useNavigate();

    const handleDelete = async () => {
        try {
            const res = await axios.delete(`https://subjectmanager-api-app.azurewebsites.net/api/subjects/${props.sid}/learningMaterials/${props.material.id}`, {
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
            <td>{formatText(props.material.name)}</td>
            <td><a href={props.material.source}>{formatText(props.material.source)}</a></td>
            <td className="table-buttons">
                <Button className="table-button" variant="dark" onClick={() => { navigate(`/subjects/${props.sid}/materials/${props.material.id}/view`) }}><EyeFill /></Button>
                <Button className="table-button" variant="primary" onClick={() => { navigate(`/subjects/${props.sid}/materials/${props.material.id}/update`) }}><PenFill /></Button>
                <Button className="table-button" variant="danger" onClick={handleDelete}><TrashFill /></Button>
            </td>
        </tr>
    );

}

export default Material;