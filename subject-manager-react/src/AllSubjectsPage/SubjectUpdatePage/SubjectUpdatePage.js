import React, { useState } from "react";
import "./SubjectUpdatePage.css";
import { useNavigate, useParams } from "react-router";
import Button from 'react-bootstrap/Button';
import 'bootstrap/dist/css/bootstrap.css';
import axios from "axios";
import { useEffect } from "react";


function SubjectUpdatePage(props) {
    const { id } = useParams();
    const navigate = useNavigate();
    const [subject, setSubject] = useState();


    const handleUpdateSubject = async (e) => {
        navigate("/subjects");
        const updatedSubject = {
            name: e.target.name.value,
            shortName: e.target.shortName.value,
            roomNumber: e.target.roomNumber.value,
            time: e.target.time.value,
            platformUrl: e.target.platformUrl.value,
            dayOfWeek: Number(e.target.dayOfWeek.value),
        }

        try {
            const res = await axios.put(`https://localhost:7158/api/subjects/${id}`, updatedSubject, {
                headers: {
                    'Authorization': localStorage.getItem("token")
                }
            });
        } catch (e) {
            alert(e);
        }


    }

    const getOneSubject = async () => {

        try {
            const res = await axios.get(`https://localhost:7158/api/subjects/${id}`,
                {
                    headers: {
                        'Authorization': localStorage.getItem("token")
                    }
                });
            return res.data;
        } catch (e) {
            alert(e);
        }

    }

    useEffect(() => {
        async function getOne() {

            const one = await getOneSubject();
            setSubject(one);
        }
        getOne()

    }, []);

    if (!subject) return <div>Loading...</div>;

    return (

        <div className="add-page">
            <form action="#" onSubmit={handleUpdateSubject}>
                <div className="add-inputs">
                    <input id="subject-add-name" type="text" name="name" placeholder="Name" maxLength={50} defaultValue={subject.name} required />
                    <input id="subject-add-short-name" type="text" name="shortName" placeholder="ShortName" maxLength={10} defaultValue={subject.shortName} required />
                    <input id="subject-add-room-number" type="number" name="roomNumber" placeholder="Room Number" defaultValue={subject.roomNumber} required />
                    <input id="subject-add-time" type="time" name="time" placeholder="Time" defaultValue={subject.time} required />
                    <input id="subject-add-platform-url" type="url" name="platformUrl" placeholder="Platform Url" defaultValue={subject.platformUrl} required />
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
                        <Button id="subject-add-button" variant="primary" type="submit" size="lg" >Update</Button>
                        <Button id="subject-add-button" variant="dark" size="lg" onClick={() => { navigate("/subjects") }}>Back</Button>
                    </div>
                </div>
            </form >


        </div >

    );
}

export default SubjectUpdatePage;