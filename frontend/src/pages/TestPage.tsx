import { Box } from '@mui/material'
import React from 'react'
import Test from '../components/Test'
import TestPageAppBar from '../components/TestPageAppBar'

const TestPage = () => {
    return (
        <Box>
            <TestPageAppBar />
            <Test />
        </Box>
    )
}

export default TestPage
