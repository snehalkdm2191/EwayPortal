import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { v4 as uuidv4 } from 'uuid';
import PortalApi from "../Api/PortalApi";

export default function ProcessData(data) {
    let { id } = useParams();
    const [pendingData, setPendingData] = useState([]);
    const [completeData, setCompleteData] = useState([]);
    const [postContent, setPostContent] = useState(null);
    useEffect(() => {
        const fetchPosts = async () => {
            const response = await PortalApi.getEmployeContent(id);
            setPendingData(response.data.contentList);
            setCompleteData(response.data.employeeContent);
        };
        fetchPosts();
    }, []);

    const CompleteProcess = async () => {
        try {
            if (postContent !== null) {
                console.log(postContent);
                await PortalApi.postEmployeeContent(postContent);
            }
        } catch (error) {
            console.log(error);
        }
    };

    const submitHandler = (data) => {
        setPostContent({
            employeeContentId: uuidv4(),
            employeeid: id,
            contentGroupId: data.contentGroupId,
            content: data.contentHeader,
        });
        CompleteProcess();
    };

    return (
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">#</th>
                    <th scope="col">Process</th>
                    <th scope="col">Action</th>
                </tr>
            </thead>
            <tbody>
                {completeData.map((data) => (
                    <tr key={data.contentId}>
                        <th scope="row">{data.contentGroupId}</th>
                        <td>{data.contentHeader}</td>
                        <td><button className='btn btn-success'>Successful..</button></td>
                    </tr>
                ))}
                {pendingData.map((data) => (
                    <tr key={data.contentId}>
                        <th scope="row">{data.contentGroupId}</th>
                        <td>{data.contentHeader}</td>
                        <td><button className='btn btn-danger' onClick={() => submitHandler(data)}>Pending..</button></td>
                    </tr>
                ))}
            </tbody>
        </table>
    );
}
