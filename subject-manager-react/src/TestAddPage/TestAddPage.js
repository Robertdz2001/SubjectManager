import React from "react";
import "./TestAddPage.css";
import Button from 'react-bootstrap/Button';
import 'bootstrap/dist/css/bootstrap.css';
import axios from "axios";
import { useNavigate, useParams } from "react-router";

function TestAddPage() {

    const { id } = useParams();
    const navigate = useNavigate();

    const handleCreate = async (e) => {
        const newTest = {
            name: e.target.name.value,
            date: e.target.date.value,
            description: e.target.description.value
        }
        e.preventDefault();

        try {
            const res = await axios.post(`https://localhost:7158/api/subjects/${id}/tests`, newTest, {
                headers: {
                    'Authorization': localStorage.getItem("token")
                }
            });
            navigate(`/subjects/view/${id}`);
        }
        catch (e) {
            alert(e);
        }
    }

    return (
        <div className="subject-add-page">
            <form action="#" onSubmit={handleCreate}>
                <div className="subject-add-inputs">
                    <input type="text" name="name" placeholder="Name" maxLength={50} required />
                    <input type="date" name="date" placeholder="Date" required />
                    <div>
                        <textarea id="test-desc" name="description" placeholder="Description"></textarea>
                    </div>
                    <div className="subject-add-buttons">
                        <Button id="subject-add-button" variant="primary" type="submit" size="lg">Create</Button>
                        <Button id="subject-add-button" variant="dark" size="lg" onClick={() => { navigate(`/subjects/view/${id}`) }}>Back</Button>
                    </div>
                </div>
            </form>


        </div>
    );
}

export default TestAddPage;