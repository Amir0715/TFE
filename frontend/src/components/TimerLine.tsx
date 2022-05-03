import { Box } from '@mui/system'
import React from 'react'

interface TimerLineProps {
    value: number,
    max: number,
    min: number,
}

const TimerLine = ({ value, max, min }: TimerLineProps) => {
    const width = (value - min) / ((max - min) / 100)
    return (
        <Box sx={{ height: "10px", backgroundColor: "red", display: "block", width: `${width}%` }} />
    )
}

export default TimerLine
