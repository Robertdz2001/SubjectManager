import React, { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router";
import "./TestViewPage.css";
import axios from "axios";
import { formatDate } from "../Test/Test";
import Button from 'react-bootstrap/Button';
import 'bootstrap/dist/css/bootstrap.css';

const getOneTest = async (sid, tid) => {

    try {
        const res = await axios.get(`https://subjectmanager-api-app.azurewebsites.net/api/subjects/${sid}/tests/${tid}`, {
            headers: {
                'Authorization': localStorage.getItem("token")
            }
        })

        return res.data;

    }
    catch (e) {
        alert(e);
    }
}


function TestViewPage() {

    const { sid, tid } = useParams();
    const [test, setTest] = useState(false);
    const navigate = useNavigate();

    useEffect(() => {
        async function getOne() {
            const one = await getOneTest(sid, tid);
            setTest(one);
        }
        getOne()
    }, []);

    if (!test) return <div>Loading...</div>;


    return (
        <div className="view-page glass-bg">
            <p>Name: {test.name}</p>
            <p>Date: {formatDate(test.date)}</p>
            <div className="test-desc"> Decription: {test.description}</div>
            <Button id="add-button" variant="dark" size="lg" onClick={() => { navigate(`/subjects/${sid}/view`) }}>Back</Button>


        </div>



    );

}

export default TestViewPage;