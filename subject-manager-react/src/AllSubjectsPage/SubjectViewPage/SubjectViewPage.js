import React, { useEffect, useState } from "react";
import "./SubjectViewPage.css";
import { useNavigate, useParams } from "react-router";
import axios from "axios";
import Button from 'react-bootstrap/Button';
import 'bootstrap/dist/css/bootstrap.css';
import TestsList from "../../TestsList/TestsList";
import { PlusCircle } from 'react-bootstrap-icons';
import { dayToString } from "../Subject/Subject";
import MaterialsList from "../../MaterialsList/MaterialsList";
import { url } from "../../App/App";
const getOneSubject = async (id) => {

    try {
        const res = await axios.get(`${url}/api/subjects/${id}`, {
            headers: {
                'Authorization': localStorage.getItem("token")
            }
        });
        return res.data;

    } catch (e) {
        alert(e);
    }


}
const getTests = async (id) => {

    try {
        const res = await axios.get(`${url}/api/subjects/${id}/tests`, {
            headers: {
                'Authorization': localStorage.getItem("token")
            }
        });
        return res.data;

    } catch (e) {
        alert(e);
    }


}
const getMaterials = async (id) => {

    try {
        const res = await axios.get(`${url}/api/subjects/${id}/learningMaterials`, {
            headers: {
                'Authorization': localStorage.getItem("token")
            }
        });
        return res.data;

    } catch (e) {
        alert(e);
    }


}

function SubjectViewPage(props) {

    const navigate = useNavigate();
    const [subject, setSubject] = useState(false);
    const { id } = useParams();
    const [tests, setTests] = useState(false);
    const [materials, setMaterials] = useState(false);
    useEffect(() => {
        async function getOne() {

            const one = await getOneSubject(id);
            const subjectsTests = await getTests(id);
            const subjectsMaterials = await getMaterials(id);
            setSubject(one);
            setTests(subjectsTests);
            setMaterials(subjectsMaterials);
        }
        getOne()

    }, []);


    if (!subject || !tests || !materials) return <div>Loading...</div>;

    return (
        <div className="subject-view-page">
            <div className="glass-bg subject-info">
                <p>Name: {subject.name}</p>
                <p>ShortName: {subject.shortName}</p>
                <p>Platform Url: <a href={subject.platformUrl}>{subject.platformUrl}</a></p>
                <p>Room Number: {subject.roomNumber}</p>
                <p>Day: {dayToString(subject.dayOfWeek)}</p>
                <p>Time: {subject.time}</p>
            </div>
            <div className="nav-buttons">
                <Button variant="primary" size="lg" onClick={() => { document.getElementById("tests").style.display = "inline-block"; document.getElementById("learning-materials").style.display = "none"; }}>Tests</Button>
                <Button variant="primary" size="lg" onClick={() => { document.getElementById("tests").style.display = "none"; document.getElementById("learning-materials").style.display = "inline-block"; }}>Learning Materials</Button>
                <Button id="add-button" variant="dark" size="lg" onClick={() => { navigate(`/subjects`) }}>Back</Button>
            </div>
            <div id="tests">
                <div className="new-test-button">
                    <Button variant="success" size="lg" onClick={() => { navigate(`/subjects/${subject.id}/tests/add`) }}><PlusCircle />New</Button>
                </div>
                <TestsList showedTests={tests} />
            </div>
            <div id="learning-materials">
                <div className="new-subject-button">
                    <Button variant="success" size="lg" onClick={() => { navigate(`/subjects/${subject.id}/materials/add`) }}><PlusCircle />New</Button>
                </div>
                <MaterialsList materials={materials} sid={subject.id} />
            </div>
        </div>
    );
}

export default SubjectViewPage;