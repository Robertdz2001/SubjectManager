import React from "react";
import "./AllTestsPage.css";
import { useNavigate } from "react-router";
import { useEffect } from "react";
import axios from "axios";
import { useState } from "react";
import TestsList from "../TestsList/TestsList";
import TestsSearchBar from "../TestsSearchBar/TestsSearchBar";
import Button from 'react-bootstrap/Button';
import 'bootstrap/dist/css/bootstrap.css';
import { url } from "../App/App";
const getAllTests = async () => {
    const res = await axios.get(
        `${url}/api/tests`,
        {
            headers: {
                'Authorization': localStorage.getItem("token")
            }
        }
    );

    return res.data;
}



function AllTestsPage() {

    const navigate = useNavigate();
    const [allTests, setAllTests] = useState(false);
    const [showedTests, setShowedTests] = useState(false);

    useEffect(() => {
        async function getAll() {

            const all = await getAllTests();
            console.log(all);
            setAllTests(all);
            setShowedTests(all);
        }
        getAll()

    }, []);

    const changeShowedTests = (searchedTests) => {
        setShowedTests(searchedTests);
    }

    if (!showedTests) return <div>Loading...</div>;

    return (
        <div className="all-page">


            <div className="all-searchbar">
                <TestsSearchBar changeShowedTests={changeShowedTests} allTests={allTests} />
                <div className="back-button"><Button id="add-button" variant="dark" size="lg" onClick={() => { navigate(`/home`) }}>Back</Button></div>
            </div>
            <div className="all-list">
                <TestsList showedTests={showedTests} />
            </div>
        </div>
    );

}

export default AllTestsPage;