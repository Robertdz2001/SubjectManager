import React, { useEffect, useState } from "react";
import { useParams } from "react-router";
import "./TestViewPage.css";
import axios from "axios";
import { formatDate } from "../Test/Test";

const getOneTest = async (sid, tid) => {

    try {
        const res = await axios.get(`https://localhost:7158/api/subjects/${sid}/tests/${tid}`, {
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


    useEffect(() => {
        async function getOne() {
            const one = await getOneTest(sid, tid);
            setTest(one);
        }
        getOne()
    }, []);

    if (!test) return <div>Loading...</div>;


    return (
        <div className="test-view-page glass-bg">
            <p>Name: {test.name}</p>
            <p>Date: {formatDate(test.date)}</p>
            <div className="test-desc"> Decription: {test.description}</div>


        </div>



    );

}

export default TestViewPage;