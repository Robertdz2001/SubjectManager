import React from "react";
import "./MaterialAddPage.css";
import Button from 'react-bootstrap/Button';
import 'bootstrap/dist/css/bootstrap.css';
import axios from "axios";
import { useNavigate, useParams } from "react-router";

function MaterialAddPage() {

    const { id } = useParams();
    const navigate = useNavigate();

    const handleCreate = async (e) => {
        const newMaterial = {
            name: e.target.name.value,
            source: e.target.source.value,
        }
        e.preventDefault();

        try {
            const res = await axios.post(`https://subjectmanager-api-app.azurewebsites.net/api/subjects/${id}/learningMaterials`, newMaterial, {
                headers: {
                    'Authorization': localStorage.getItem("token")
                }
            });
            navigate(`/subjects/${id}/view`);
        }
        catch (e) {
            alert(e);
        }
    }

    return (
        <div className="add-page">
            <form action="#" onSubmit={handleCreate}>
                <div className="add-inputs">
                    <input type="text" name="name" placeholder="Name" maxLength={30} required />
                    <input type="url" name="source" placeholder="Source" required />
                    <div className="add-buttons">
                        <Button id="add-button" variant="primary" type="submit" size="lg">Create</Button>
                        <Button id="add-button" variant="dark" size="lg" onClick={() => { navigate(`/subjects/${id}/view`) }}>Back</Button>
                    </div>
                </div>
            </form>


        </div>
    );
}

export default MaterialAddPage;