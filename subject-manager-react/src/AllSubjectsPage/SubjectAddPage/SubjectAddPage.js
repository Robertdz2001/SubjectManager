import React from "react";
import "./SubjectAddPage.css";
import Button from 'react-bootstrap/Button';
import 'bootstrap/dist/css/bootstrap.css';
import axios from "axios";
import { useNavigate } from "react-router";


function SubjectAddPage(props) {

    const navigate = useNavigate();
    const handleCreateSubject = async (e) => {

        const newSubject = {
            name: e.target.name.value,
            shortName: e.target.shortName.value,
            roomNumber: e.target.roomNumber.value,
            platformUrl: e.target.platformUrl.value,
            time: e.target.time.value,
            dayOfWeek: Number(e.target.dayOfWeek.value),

        }
        console.log(newSubject);
        e.preventDefault();
        try {
            const resp = await axios.post(`https://localhost:7158/api/subjects`, newSubject,
                {
                    headers: {
                        'Authorization': localStorage.getItem("token")
                    }
                });

            navigate("/subjects");
        } catch (err) {
            console.error(err);
        }

    }

    return (
        <div className="add-page">
            <form onSubmit={handleCreateSubject}>
                <div className="add-inputs">
                    <input id="subject-add-name" type="text" name="name" placeholder="Name" maxLength={50} required />
                    <input id="subject-add-short-name" type="text" name="shortName" placeholder="ShortName" maxLength={10} required />
                    <input id="subject-add-room-number" type="number" name="roomNumber" placeholder="Room Number" required />
                    <input id="subject-add-time" type="time" name="time" placeholder="Time" required />
                    <input id="subject-add-platform-url" type="url" name="platformUrl" placeholder="Platform Url" required />
                    <select className="add-day" name="dayOfWeek" required>
                        <option value="">Day Of Week</option>
                        <option value="1">Monday</option>
                        <option value="2">Tuesday</option>
                        <option value="3">Wednesday</option>
                        <option value="4">Thursday</option>
                        <option value="5">Friday</option>
                        <option value="6">Saturday</option>
                        <option value="0">Sunday</option>
                    </select>
                    <div className="add-buttons">
                        <Button id="subject-add-button" variant="primary" type="submit" size="lg">Create</Button>
                        <Button id="subject-add-button" variant="dark" size="lg" onClick={() => { navigate("/subjects") }}>Back</Button>
                    </div>
                </div>
            </form>


        </div>



    );
}


export default SubjectAddPage;