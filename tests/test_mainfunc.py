import subprocess
import pytest

def test_main_function():
    script_path = "matrixCalcMain.py"
    expected_output = "Enter the size of the matrix: "

    result = subprocess.run(["python", script_path], stdout=subprocess.PIPE, stderr=subprocess.PIPE, text=True)

    assert result.stdout == expected_output
