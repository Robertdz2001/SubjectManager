import React, { useEffect, useState } from "react";
import "./SubjectViewPage.css";
import { useParams } from "react-router";
import axios from "axios";
import Button from 'react-bootstrap/Button';
import 'bootstrap/dist/css/bootstrap.css';
import TestsSearchBar from "../../TestsSearchBar/TestsSearchBar";
import TestsList from "../../TestsList/TestsList";
const getOneSubject = async (id) => {

    try {
        const res = await axios.get(`https://localhost:7158/api/subjects/${id}`, {
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
        const res = await axios.get(`https://localhost:7158/api/subjects/${id}/tests`, {
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
        const res = await axios.get(`https://localhost:7158/api/subjects/${id}/learningMaterials`, {
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


    if (!subject || !tests) return <div>Loading...</div>;

    return (
        <div className="subject-view-page">
            <div className="glass-bg subject-info">
                <p>Name: {subject.name}</p>
                <p>ShortName: {subject.shortName}</p>
                <p>Platform Url: <a href={subject.platformUrl}>{subject.platformUrl}</a></p>
                <p>Room Number: {subject.roomNumber}</p>
                <p>Day: {subject.dayOfWeek}</p>
                <p>Time: {subject.time}</p>
            </div>
            <Button variant="primary" onClick={() => { document.getElementById("tests").style.display = "block"; document.getElementById("learning-materials").style.display = "none"; }}>Tests</Button>
            <Button variant="primary" onClick={() => { document.getElementById("tests").style.display = "none"; document.getElementById("learning-materials").style.display = "block"; }}>Learning Materials</Button>

            <div id="tests"><TestsList showedTests={tests} /></div>
            <div id="learning-materials">{materials[0].name}</div>
        </div>
    );
}

export default SubjectViewPage;