#!/bin/bash

ORG="bth-csharp"  # Ändra till din organisation

# Labels att skapa (namn, färg, beskrivning)
declare -A LABELS
LABELS["Submitted"]="0052CC|Used by git workflow to mark submission"
LABELS["Tests-passed"]="0052CC|Automated tests passed, wait for a teacher to look at your submission"
LABELS["Tests-failed"]="d73a4a|Something in the automated tests failed. Look it up and fix it."
LABELS["Needs improvement"]="B60205|Used by teachers to mark submission for resubmission"
LABELS["Submission not approved"]="5319e7|Used by teachers to mark submission as not fulfilling the requirements."
LABELS["Approved"]="0E8A16|Used by teachers to pass student submissions"
LABELS["Re-submitted"]="1d76db|Used by students when turning in after getting 'Needs improvement' from a teacher."

# Lista alla repos som börjar med 'csharp'
repos=$(gh repo list $ORG --limit 200 --json name -q '.[] | select(.name | startswith("csharp-")) | .name')

for repo in $repos; do
    echo "Skapar labels i $repo..."
    for label in "${!LABELS[@]}"; do
        color_desc=${LABELS[$label]}
        color=${color_desc%%|*}
        desc=${color_desc#*|}
        gh api \
          repos/$ORG/$repo/labels \
          -f name="$label" \
          -f color="$color" \
          -f description="$desc" \
          || echo "Label '$label' finns redan i $repo"
    done
done